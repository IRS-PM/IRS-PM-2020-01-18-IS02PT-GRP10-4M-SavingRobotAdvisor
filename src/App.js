import React, {useEffect, useRef} from 'react';
import AppBar from '@material-ui/core/AppBar';
import CssBaseline from '@material-ui/core/CssBaseline';
import Drawer from '@material-ui/core/Drawer';
import Hidden from '@material-ui/core/Hidden';
import IconButton from '@material-ui/core/IconButton';
import MenuIcon from '@material-ui/icons/Menu';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import {makeStyles, useTheme} from '@material-ui/core/styles';
import TextField from "@material-ui/core/TextField";
import InputAdornment from "@material-ui/core/InputAdornment";
import {
    AccountBalance,
    CreditCard, FlightTakeoff,
    Launch,
    LocalDining,
    LocalGasStation,
    MonetizationOn, PhoneAndroid,
    ShoppingCart,
    Train
} from "@material-ui/icons";
import Button from "@material-ui/core/Button";
import Grid from "@material-ui/core/Grid";
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Link from "@material-ui/core/Link";
import Tooltip from "@material-ui/core/Tooltip";
import Slider from "@material-ui/core/Slider";
import Input from "@material-ui/core/Input";
import CircularProgress from "@material-ui/core/CircularProgress";
import {green} from "@material-ui/core/colors";

const drawerWidth = 275;
//const apiServer = "gvinto.synology.me:32786";
const apiServer = "localhost:5000";

const useStyles = makeStyles(theme => ({
    root: {
        display: 'flex',
        marginBottom:10,
    },
    drawer: {
        [theme.breakpoints.up('sm')]: {
            width: drawerWidth,
            flexShrink: 0,
        },

    },
    appBar: {
        [theme.breakpoints.up('sm')]: {
            width: `calc(100% - ${drawerWidth}px)`,
            marginLeft: drawerWidth,
        },
    },
    menuButton: {
        marginRight: theme.spacing(2),
        [theme.breakpoints.up('sm')]: {
            display: 'none',
        },
    },
    toolbar: theme.mixins.toolbar,
    container: {
        width: drawerWidth-30,
        marginLeft: 15,
    },
    drawerPaper: {
        width: drawerWidth,
    },
    content: {
        flexGrow: 1,
        padding: theme.spacing(3),
    },

    bullet: {
        display: 'inline-block',
        margin: '0 2px',
        transform: 'scale(0.8)',
    },
    title: {
        fontSize: 16,
        fontWeight: 'bold',
        textDecorationLine: 'underline',
    },
    pos: {
        fontSize: 11,
        marginBottom: 14,
    },
    input: {
        width: 52,
        textAlign:'right',
    },
    buttonProgress: {
        color: green[500],
        position: 'absolute',
        left: '50%',
        marginTop: 6,
        marginLeft: -12,
    },
}));

const initialList = [];

let accountInfo = [];
accountInfo["CitiMaxiGain"]={"name":"Citi MaxiGain","url":"https://www.citibank.com.sg/gcb/deposits/mxgn-savacc.htm"};
accountInfo["OCBC360"]={"name":"OCBC 360","url":"https://www.ocbc.com/personal-banking/accounts/360-account.html"};
accountInfo["MaybankSaveUp"]={"name":"Maybank SaveUp","url":"https://www.maybank2u.com.sg/en/personal/saveup/save-up-programme.page"};
accountInfo["CIMBFastSaver"]={"name":"CIMB FastSaver","url":"https://www.cimbbank.com.sg/en/personal/products/accounts/savings-accounts/cimb-fastsaver-account.html"};
accountInfo["SCBonusSaver"]={"name":"SC Bonus$aver","url":"https://www.sc.com/sg/save/current-accounts/bonussaver/"};
accountInfo["Multiplier"]={"name":"DBS Multiplier","url":"https://www.dbs.com.sg/personal/deposits/bank-earn/multiplier"};
accountInfo["UOBONE"]={"name":"UOB ONE","url":"https://www.uob.com.sg/personal/save/chequeing/one-account.page"};
accountInfo["BOCSmartSaver"]={"name":"BOC SmartSaver","url":"https://www.bankofchina.com/sg/pbservice/pb1/201611/t20161130_8271280.html"};

let cardInfo = [];
cardInfo["CitiCashback"]={"name":"Citi Cashback","url":"https://www.citibank.com.sg/gcb/credit_cards/dividend-card.htm"};
cardInfo["OCBC365"]={"name":"OCBC 365","url":"https://www.ocbc.com/personal-banking/cards/365-cashback-credit-card"};
cardInfo["MaybankFamilyAndFriends"]={"name":"Maybank Family And Friends","url":"https://www.maybank2u.com.sg/en/personal/cards/credit/maybank-family-and-friends-mastercard.page"};
cardInfo["CIMBSignature"]={"name":"CIMB Signature","url":"https://www.cimbbank.com.sg/en/personal/products/cards/credit-cards/cimb-visa-signature.html"};
cardInfo["SCUnlimitedCashback"]={"name":"SC Unlimited Cashback","url":"https://www.sc.com/sg/credit-cards/unlimited-cashback-credit-card/"};
cardInfo["POSBEveryday"]={"name":"POSB Everyday","url":"https://www.posb.com.sg/personal/cards/credit-cards/posb-everyday-card"};
cardInfo["UOBONE"]={"name":"UOB ONE","url":"https://www.uob.com.sg/personal/cards/credit/one/"};
cardInfo["BOCFamily"]={"name":"BOC Family","url":"https://www.bankofchina.com/sg/bcservice/bc1/201605/t20160503_6891836.html"};

function processResult(row) {
    if (cardInfo[row.card]) {
        row.cardName = cardInfo[row.card].name;
        row.cardUrl = cardInfo[row.card].url;
    }

    if (accountInfo[row.account]) {
        row.accountName = accountInfo[row.account].name;
        row.accountUrl = accountInfo[row.account].url;
    }

    return row
}

export function SimpleCard(props) {
    const classes = useStyles();

    return (
        <Card className={classes.root}>

            <CardContent>
                <img alt={props.image} src={process.env.PUBLIC_URL + props.image + '.png'} />
            </CardContent>
            <CardContent>
                <Typography className={classes.title} color="textPrimary" gutterBottom>
                    Bank: {props.bank}
                </Typography>
                <Typography variant="body2" component="p">
                    Bank account: {props.accountName} <Tooltip title={"Open " + props.accountName + " website"}><Link target="_blank" href={props.accountUrl}><Launch fontSize="inherit"/></Link></Tooltip><br/>
                    Credit card:  {props.cardName} <Tooltip title={"Open " + props.cardName + " website"}><Link target="_blank" href={props.cardUrl}><Launch fontSize="inherit"/></Link></Tooltip><br/><br/>
                </Typography>
                <Typography variant="h7" component="h4">
                    Annual Value: ${props.combined.toFixed(2)}<br/>
                    Savings interest: ${props.interest.toFixed(2)} ({props.interest_rate.toFixed(2)}%)<br/>
                    Credit cashback: ${props.cashback.toFixed(2)} ({props.cashback_rate.toFixed(2)}%)<br/>
                </Typography>
                <Typography className={classes.pos} color="textSecondary">
                    * Effective interest/cashback rate in brackets
                </Typography>
            </CardContent>
            <CardActions>

            </CardActions>

        </Card>
    );
}

function ResponsiveDrawer(props) {
    const [income, setIncome] = React.useState(3500);
    const [expense, setExpense] = React.useState(1000);
    const [savings, setSavings] = React.useState(30000);
    const [results, setResults] = React.useState(initialList);
    const [incomeError, setIncomeError] = React.useState('');
    const [expenseError, setExpenseError] = React.useState('');
    const [savingsError, setSavingsError] = React.useState('');
    const [groceryValue, setGroceryValue] = React.useState(30/100*expense);
    const [diningValue, setDiningValue] = React.useState(25/100*expense);
    const [publicTransportValue, setPublicTransportValue] = React.useState(5/100*expense);
    const [petrolValue, setPetrolValue] = React.useState(20/100*expense);
    const [telcoValue, setTelcoValue] = React.useState(5/100*expense);
    const [travelValue, setTravelValue] = React.useState(10/100*expense);
    const [loading, setLoading] = React.useState(false);

    const {container} = props;
    const classes = useStyles();
    const theme = useTheme();
    const [mobileOpen, setMobileOpen] = React.useState(false);
    const myRef = useRef(null);

    useEffect(() => {
        document.title = "Savings Robot Advisor"
    }, []);

    const handleDrawerToggle = () => {
        setMobileOpen(!mobileOpen);
    };

    const handleIncomeChange = event => {
        if (event.target.value.length > 0 && event.target.value >= 0) {
            setIncomeError("");
        } else {
            setIncomeError("true");
        }
        setIncome(event.target.value === '' ? '' : Number(event.target.value));
    };
    const handleSavingsChange = event => {
        if (event.target.value.length > 0 && event.target.value >= 0) {
            setSavingsError("");
        } else {
            setSavingsError("true");
        }
        setSavings(event.target.value === '' ? '' : Number(event.target.value));
    };
    const handleExpenseChange = event => {
        if (event.target.value.length > 0 && event.target.value >= 0) {
            setExpenseError("");
        } else {
            setExpenseError("true");
        }
        setExpense(event.target.value === '' ? '' : Number(event.target.value));
        if (Number(event.target.value) < groceryValue+diningValue+publicTransportValue+petrolValue+telcoValue+travelValue) {
            setGroceryValue(0);
            setDiningValue(0);
            setPublicTransportValue(0);
            setPetrolValue(0);
            setTelcoValue(0);
            setTravelValue(0);
        }
    };

    const handleGrocerySliderChange = (event, newValue) => {
        if((newValue/100*expense)+diningValue+publicTransportValue+petrolValue+telcoValue+travelValue <= expense) {
            setGroceryValue(Math.round(newValue / 100 * expense));
        }
    };
    const handleGroceryInputChange = (event) => {
        if (event.target.value < 0) {
            setGroceryValue(0);
        } else if (Number(event.target.value)+diningValue+publicTransportValue+petrolValue+telcoValue+travelValue > expense) {
            setGroceryValue(expense-(diningValue+publicTransportValue+petrolValue+telcoValue+travelValue));
        } else {
            setGroceryValue(event.target.value === '' ? '' : Number(event.target.value));
        }
    };

    const handleDiningSliderChange = (event, newValue) => {
        if(groceryValue+(newValue/100*expense)+publicTransportValue+petrolValue+telcoValue+travelValue <= expense) {
            setDiningValue(Math.round(newValue / 100 * expense));
        }
    };
    const handleDiningInputChange = (event) => {
        if (event.target.value < 0) {
            setDiningValue(0);
        } else if (groceryValue+Number(event.target.value)+publicTransportValue+petrolValue+telcoValue+travelValue > expense) {
            setDiningValue(expense-(groceryValue+publicTransportValue+petrolValue+telcoValue+travelValue));
        } else {
            setDiningValue(event.target.value === '' ? '' : Number(event.target.value));
        }
    };

    const handlePublicTransportSliderChange = (event, newValue) => {
        if(groceryValue+diningValue+(newValue/100*expense)+petrolValue+telcoValue+travelValue <= expense) {
            setPublicTransportValue(Math.round(newValue/100*expense));
        }
    };
    const handlePublicTransportInputChange = (event) => {
        if (event.target.value < 0) {
            setPublicTransportValue(0);
        } else if (groceryValue+diningValue+Number(event.target.value)+petrolValue+telcoValue+travelValue > expense) {
            setPublicTransportValue(expense-(groceryValue+diningValue+petrolValue+telcoValue+travelValue));
        } else {
            setPublicTransportValue(event.target.value === '' ? '' : Number(event.target.value));
        }
    };

    const handlePetrolSliderChange = (event, newValue) => {
        if(groceryValue+diningValue+publicTransportValue+(newValue/100*expense)+telcoValue+travelValue <= expense) {
            setPetrolValue(Math.round(newValue / 100 * expense));
        }
    };
    const handlePetrolInputChange = (event) => {
        if (event.target.value < 0) {
            setPetrolValue(0);
        } else if (groceryValue+diningValue+publicTransportValue+Number(event.target.value)+telcoValue+travelValue > expense) {
            setPetrolValue(expense-(groceryValue+diningValue+publicTransportValue+telcoValue+travelValue));
        } else {
            setPetrolValue(event.target.value === '' ? '' : Number(event.target.value));
        }
    };

    const handleTelcoSliderChange = (event, newValue) => {
        if(groceryValue+diningValue+publicTransportValue+petrolValue+(newValue/100*expense)+travelValue <= expense) {
            setTelcoValue(Math.round(newValue / 100 * expense));
        }
    };
    const handleTelcoInputChange = (event) => {
        if (event.target.value < 0) {
            setTelcoValue(0);
        } else if (groceryValue+diningValue+publicTransportValue+petrolValue+Number(event.target.value)+travelValue > expense) {
            setTelcoValue(expense-(groceryValue+diningValue+publicTransportValue+petrolValue+travelValue));
        } else {
            setTelcoValue(event.target.value === '' ? '' : Number(event.target.value));
        }
    };

    const handleTravelSliderChange = (event, newValue) => {
        if(groceryValue+diningValue+publicTransportValue+petrolValue+telcoValue+(newValue/100*expense) <= expense) {
            setTravelValue(Math.round(newValue / 100 * expense));
        }
    };
    const handleTravelInputChange = (event) => {
        if (event.target.value < 0) {
            setTravelValue(0);
        } else if (groceryValue+diningValue+publicTransportValue+petrolValue+telcoValue+Number(event.target.value) > expense) {
            setTravelValue(expense-(groceryValue+diningValue+publicTransportValue+petrolValue+telcoValue));
        } else {
            setTravelValue(event.target.value === '' ? '' : Number(event.target.value));
        }
    };

    const compareButtonClick = event => {
        if (income && expense && savings && income >= 0 && expense >= 0 && savings >= 0) {
            setLoading(true);
            fetch('http://'+apiServer+'/api/SavingRobotAdvisor', {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify("{\"Income\":"+income+
                                            ",\"Balance\":"+savings+
                                            ",\"MonthlySpending\":{\"TotalAmount\":"+expense+
                                                                ",\"GroceryPercent\":"+groceryValue/expense*100+
                                                                ",\"DiningPercent\":"+diningValue/expense*100+
                                                                ",\"PublicTransportPercent\":"+publicTransportValue/expense*100+
                                                                ",\"PetrolPercent\":"+petrolValue/expense*100+
                                                                ",\"TelcoPercent\":"+telcoValue/expense*100+
                                                                ",\"TravelPercent\":"+travelValue/expense*100+"}}"),
                credentials: "same-origin"
            })
                .then(res => res.json())
                .then((data) => {
                    //console.log(data);
                    data.sort((a, b) => (a.interest + a.rebate > b.interest + b.rebate) ? -1 : 1);
                    const results = data.map(processResult);
                    //console.log(results);
                    setResults(results);
                    setLoading(false);
                    window.scrollTo({
                        top: myRef.current.offsetTop-80,
                        left: 0,
                        behavior: 'smooth'
                    });
                })
                .catch(console.log);
        } else {
            if (!income) {
                setIncomeError("true");
            }
            if (!expense) {
                setExpenseError("true");
            }
            if (!savings) {
                setSavingsError("true");
            }
        }

        event.preventDefault();
    };

    const drawer = (

        <div className={classes.drawerPaper}>
            <Grid
                container
                spacing={1}
                direction="row"
                alignItems="stretch"
                justify="center"
                className={classes.container}
            >
                <Grid item xs={12}>
                    <TextField
                        required
                        id="incomeText"
                        label="Monthly net income"
                        margin={"normal"}
                        variant="outlined"
                        InputProps={{
                            startAdornment: (
                                <InputAdornment position="start">
                                    <MonetizationOn/>
                                </InputAdornment>
                            ),
                        }}
                        error={incomeError}
                        value={income}
                        onChange={handleIncomeChange}
                    />
                </Grid>

                <Grid item xs={12}>
                    <TextField
                        required
                        id="savingsText"
                        label="Cash Savings"
                        margin={"normal"}
                        variant="outlined"
                        InputProps={{
                            startAdornment: (
                                <InputAdornment position="start">
                                    <AccountBalance/>
                                </InputAdornment>
                            ),
                        }}
                        error={savingsError}
                        value={savings}
                        onChange={handleSavingsChange}
                    />
                </Grid>
                <Grid item xs={12}>
                    <TextField
                        required
                        id="expensesText"
                        label="Monthly credit card expenses"
                        margin={"normal"}
                        variant="outlined"
                        InputProps={{
                            startAdornment: (
                                <InputAdornment position="start">
                                    <CreditCard/>
                                </InputAdornment>
                            ),
                        }}
                        error={expenseError}
                        value={expense}
                        onChange={handleExpenseChange}
                    />
                </Grid>

                <Grid item xs={2}>
                    <ShoppingCart/>
                </Grid>
                <Grid item xs={10}>
                    <Slider
                        value={typeof groceryValue === 'number' ? groceryValue/expense*100 : 0}
                        onChange={handleGrocerySliderChange}
                    />
                </Grid>
                <Grid item xs={3}>
                    {Math.round(groceryValue/expense*100)}%
                </Grid>
                <Grid item xs={5} >
                        Grocery
                </Grid>
                <Grid item xs={4} >
                    $<Input
                        className={classes.input}
                        value={groceryValue}
                        margin="dense"
                        onChange={handleGroceryInputChange}
                    />

                </Grid>

                <Grid item xs={2}>
                    <LocalDining/>
                </Grid>
                <Grid item xs={10}>
                    <Slider
                        value={typeof diningValue === 'number' ? diningValue/expense*100 : 0}
                        onChange={handleDiningSliderChange}
                    />
                </Grid>
                <Grid item xs={3}>
                    {Math.round(diningValue/expense*100)}%
                </Grid>
                <Grid item xs={5} >
                    Dining
                </Grid>
                <Grid item xs={4} >
                    $<Input
                    className={classes.input}
                    value={diningValue}
                    margin="dense"
                    onChange={handleDiningInputChange}
                />
                </Grid>

                <Grid item xs={2}>
                    <Train/>
                </Grid>
                <Grid item xs={10}>
                    <Slider
                        value={typeof publicTransportValue === 'number' ? publicTransportValue/expense*100 : 0}
                        onChange={handlePublicTransportSliderChange}
                    />
                </Grid>
                <Grid item xs={3}>
                    {Math.round(publicTransportValue/expense*100)}%
                </Grid>
                <Grid item xs={5} >
                    Transport
                </Grid>
                <Grid item xs={4} >
                    $<Input
                    className={classes.input}
                    value={publicTransportValue}
                    margin="dense"
                    onChange={handlePublicTransportInputChange}
                />
                </Grid>

                <Grid item xs={2}>
                    <LocalGasStation/>
                </Grid>
                <Grid item xs={10}>
                    <Slider
                        value={typeof petrolValue === 'number' ? petrolValue/expense*100 : 0}
                        onChange={handlePetrolSliderChange}
                    />
                </Grid>
                <Grid item xs={3}>
                    {Math.round(petrolValue/expense*100)}%
                </Grid>
                <Grid item xs={5} >
                    Petrol
                </Grid>
                <Grid item xs={4} >
                    $<Input
                    className={classes.input}
                    value={petrolValue}
                    margin="dense"
                    onChange={handlePetrolInputChange}
                />
                </Grid>

                <Grid item xs={2}>
                    <PhoneAndroid/>
                </Grid>
                <Grid item xs={10}>
                    <Slider
                        value={typeof telcoValue === 'number' ? telcoValue/expense*100 : 0}
                        onChange={handleTelcoSliderChange}
                    />
                </Grid>
                <Grid item xs={3}>
                    {Math.round(telcoValue/expense*100)}%
                </Grid>
                <Grid item xs={5} >
                    Telco
                </Grid>
                <Grid item xs={4} >
                    $<Input
                    className={classes.input}
                    value={telcoValue}
                    margin="dense"
                    onChange={handleTelcoInputChange}
                />
                </Grid>

                <Grid item xs={2}>
                    <FlightTakeoff/>
                </Grid>
                <Grid item xs={10}>
                    <Slider
                        value={typeof travelValue === 'number' ? travelValue/expense*100 : 0}
                        onChange={handleTravelSliderChange}
                    />
                </Grid>
                <Grid item xs={3}>
                    {Math.round(travelValue/expense*100)}%
                </Grid>
                <Grid item xs={5} >
                    Travel
                </Grid>
                <Grid item xs={4} >
                    $<Input
                    className={classes.input}
                    value={travelValue}
                    margin="dense"
                    onChange={handleTravelInputChange}
                />
                </Grid>


                <Grid item xs={3} >
                    {Math.round((expense-(groceryValue+diningValue+publicTransportValue+petrolValue+telcoValue+travelValue))/expense*100)}%
                </Grid>
                <Grid item xs={5} >
                    Others
                </Grid>
                <Grid item xs={4} >
                    ${Math.round(expense-(groceryValue+diningValue+publicTransportValue+petrolValue+telcoValue+travelValue))}
                </Grid>


                <Grid item xs={12}>
                    <div>
                        <Button onClick={compareButtonClick} variant="contained" fullWidth={true} disabled={loading} color="primary">
                            Compare Banks
                        </Button>
                        {loading && <CircularProgress size={24} className={classes.buttonProgress} />}
                    </div>
                </Grid>
            </Grid>
        </div>

    );

    return (
        <div className={classes.root}>
            <CssBaseline/>
            <AppBar position="fixed" className={classes.appBar}>
                <Toolbar>
                    <IconButton
                        color="inherit"
                        aria-label="open drawer"
                        edge="start"
                        onClick={handleDrawerToggle}
                        className={classes.menuButton}
                    >
                        <MenuIcon/>
                    </IconButton>
                    <Typography variant="h6" noWrap>
                        Savings Robot Advisor
                    </Typography>
                </Toolbar>
            </AppBar>
            <nav className={classes.drawer} aria-label="mailbox folders">
                {/* The implementation can be swapped with js to avoid SEO duplication of links. */}
                <Hidden smUp implementation="css">
                    <Drawer
                        container={container}
                        variant="temporary"
                        anchor={theme.direction === 'rtl' ? 'right' : 'left'}
                        open={mobileOpen}
                        onClose={handleDrawerToggle}
                        classes={{
                            paper: classes.drawerPaper,
                        }}
                        ModalProps={{
                            keepMounted: true, // Better open performance on mobile.
                        }}
                    >
                        {drawer}
                    </Drawer>
                </Hidden>
                <Hidden xsDown implementation="css">
                    <Drawer
                        classes={{
                            paper: classes.drawerPaper,
                        }}
                        variant="permanent"
                        open
                    >
                        {drawer}
                    </Drawer>
                </Hidden>
            </nav>
            <main className={classes.content}>
                <div className={classes.toolbar}/>
                <img width='600' alt='Savings Robot Advisor logo ' src={process.env.PUBLIC_URL + 'Logo_Text.png'} />
                <Typography paragraph>
                    Our robot advisor will help you pick the savings account and credit card with the
                    <ul>
                        <li>Highest annual interest on your savings</li>
                        <li>Best credit card rebate</li>
                    </ul>
                    Please enter in the left column your:
                    <ul>
                        <li>Monthly net salary</li>
                        <li>Current cash savings</li>
                        <li>Monthly credit card expenses on:</li>
                        <ul>
                            <li>Groceries</li>
                            <li>Dining</li>
                            <li>Public Transport</li>
                            <li>Petrol</li>
                            <li>Telco bills</li>
                            <li>Travel</li>
                        </ul>
                    </ul>
                </Typography>
                <div ref={myRef}>

                    {results.map(item => (

                            <SimpleCard bank={item.bank}
                                        accountName={item.accountName}
                                        accountUrl={item.accountUrl}
                                        cardName={item.cardName}
                                        cardUrl={item.cardUrl}
                                        image={item.card}
                                        combined={item.interest + item.rebate}
                                        interest={item.interest}
                                        interest_rate={item.interest_rate}
                                        cashback={item.rebate}
                                        cashback_rate={item.rebate_rate}
                            />

                    ))}

                </div>
            </main>
        </div>
    );
}

export default ResponsiveDrawer;
